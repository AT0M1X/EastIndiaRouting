import axios from 'axios';
import config from "./ClientConfiguration"; // For dynamic config loggingendpoint

type ClientLogging = {
    messageTemplate: string, 
    properties: string
}

export enum LogEventLevel {
    debug = "debug",
    information = "information",
    warning = "warning",
    error = "error",
    critical = "critical",
    trace = "trace"
}

const path: string = "clientlogging/";

const post = async (level: string, messageTemplate: string, properties: string) => {
    const rcc = await config.getData();
    const logging: ClientLogging = { messageTemplate: messageTemplate, properties: properties };
    axios.post(`${rcc.loggingEndpoint}/${path}${level}`, logging);
    axios.post(`/${path}${level}`, logging);
}
export const LogDebug = (errorOrMessageTemplate: Error | string, ...properties: any[]) => {
    try {
        if (errorOrMessageTemplate instanceof Error) {
            Write(LogEventLevel.debug, properties[0], properties.slice(1), errorOrMessageTemplate);
        } else {
            Write(LogEventLevel.debug, errorOrMessageTemplate, properties);
        }
    } catch (error) {
        console.log(error);
    }
};

export const LogInformation = (errorOrMessageTemplate: Error | string, ...properties: any[]) => {
    try {
        if (errorOrMessageTemplate instanceof Error) {
            Write(LogEventLevel.information, properties[0], properties.slice(1), errorOrMessageTemplate);
        } else {
            Write(LogEventLevel.information, errorOrMessageTemplate, properties);
        }
    } catch (error) {
        console.log(error);
    }
};

export const LogWarning = (errorOrMessageTemplate: Error | string, ...properties: any[]) => {
    try {
        if (errorOrMessageTemplate instanceof Error) {
            Write(LogEventLevel.warning, properties[0], properties.slice(1), errorOrMessageTemplate);
        } else {
            Write(LogEventLevel.warning, errorOrMessageTemplate, properties);
        }
    } catch (error) {
        console.log(error);
    }
};

export const LogError = (errorOrMessageTemplate: Error | string, ...properties: any[]) => {
    try {
        if (errorOrMessageTemplate instanceof Error) {
            Write(LogEventLevel.error, properties[0], properties.slice(1), errorOrMessageTemplate);
        } else {
            Write(LogEventLevel.error, errorOrMessageTemplate, properties);
        }
    } catch (error) {
        console.log(error);
    }
};

export const LogCritical = (errorOrMessageTemplate: Error | string, ...properties: any[]) => {
    try {
        if (errorOrMessageTemplate instanceof Error) {
            Write(LogEventLevel.critical, properties[0], properties.slice(1), errorOrMessageTemplate);
        } else {
            Write(LogEventLevel.critical, errorOrMessageTemplate, properties);
        }
    } catch (error) {
        console.log(error);
    }
};

export const LogTrace = (errorOrMessageTemplate: Error | string, ...properties: any[]) => {
    try {
        if (errorOrMessageTemplate instanceof Error) {
            Write(LogEventLevel.trace, properties[0], properties.slice(1), errorOrMessageTemplate);
        } else {
            Write(LogEventLevel.trace, errorOrMessageTemplate, properties);
        }
    } catch (error) {
        console.log(error);
    }
};



const Write = (level: LogEventLevel, rawMessageTemplate: string, unboundProperties: any[], error?: Error) => {
    const messageTemplate = new MessageTemplate(rawMessageTemplate);
    const properties = messageTemplate.bindProperties(unboundProperties);
    post(level, rawMessageTemplate, JSON.stringify(properties));
}

const tokenizer = /\{@?\w+}/g;

interface Token {
  name?: string;
  text?: string;
  destructure?: boolean;
  raw?: string;
}

/**
 * Represents a message template that can be rendered into a log message.
 */
export class MessageTemplate {
  /**
   * Gets or sets the raw message template of this instance.
   */
  raw: string;

  private tokens: Token[];

  /**
   * Creates a new MessageTemplate instance with the given template.
   */
  constructor(messageTemplate: string) {
    if (messageTemplate === null || !messageTemplate.length) {
      throw new Error('Argument "messageTemplate" is required.');
    }

    this.raw = messageTemplate;
    this.tokens = this.tokenize(messageTemplate);
  }


  /**
   * Renders this template using the given properties.
   * @param {Object} properties Object containing the properties.
   * @returns Rendered message.
   */
  render(properties?: Object): string {
    if (!this.tokens.length) {
      return this.raw;
    }
    properties = properties || new Object();
    const result = [] as any;
    for (var i = 0; i < this.tokens.length; ++i) {
      const token = this.tokens[i];
      if (typeof token.name === 'string') {
        if (properties.hasOwnProperty(token.name)) {
          result.push(this.toText(properties[token.name]))
        } else {
          result.push(token.raw);
        }
      } else {
        result.push(token.text);
      }
    }
    return result.join('');
  }

  /**
   * Binds the given set of args to their matching tokens.
   * @param {any} positionalArgs Arguments.
   * @returns Object containing the properties.
   */
  bindProperties(positionalArgs: any): Object {
    const result = {};
    let nextArg = 0;
    for (var i = 0; i < this.tokens.length && nextArg < positionalArgs.length; ++i) {
      const token = this.tokens[i];
      if (typeof token.name === 'string') {
        let p = positionalArgs[nextArg];
        result[token.name] = this.capture(p, token.destructure);
        nextArg++;
      }
    }

    while (nextArg < positionalArgs.length) {
      const arg = positionalArgs[nextArg];
      if (typeof arg !== 'undefined') {
        result['a' + nextArg] = this.capture(arg);
      }
      nextArg++;
    }

    return result;
  }

  private tokenize(template: string): Token[] {
    const tokens = [] as any;

    let result;
    let textStart;

    while ((result = tokenizer.exec(template)) !== null) {
      if (result.index !== textStart) {
        tokens.push({ text: template.slice(textStart, result.index) });
      }

      let destructure = false;

      let token = result[0].slice(1, -1);
      if (token.indexOf('@') === 0) {
        token = token.slice(1);
        destructure = true;
      }

      tokens.push({
        name: token,
        destructure,
        raw: result[0]
      });

      textStart = tokenizer.lastIndex;
    }

    if (textStart >= 0 && textStart < template.length) {
      tokens.push({ text: template.slice(textStart) });
    }

    return tokens;
  }

  private toText(property: any): string {
    if (typeof property === 'undefined') {
      return 'undefined';
    }

    if (property === null) {
      return 'null';
    }

    if (typeof property === 'string') {
      return property;
    }

    if (typeof property === 'number') {
      return property.toString();
    }

    if (typeof property === 'boolean') {
      return property.toString();
    }

    if (typeof property.toISOString === 'function') {
      return property.toISOString();
    }

    if (typeof property === 'object') {
      let s = JSON.stringify(property);
      if (s.length > 70) {
        s = s.slice(0, 67) + '...';
      }

      return s;
    }

    return property.toString();
  };

  private capture(property: any, destructure?: boolean): Object {
    if (typeof property === 'function') {
      return property.toString();
    }

    if (typeof property === 'object') {
      // null value will be automatically stringified as "null", in properties it will be as null
      // otherwise it will throw an error
      if (property === null) {
        return property;
      }

      // Could use instanceof Date, but this way will be kinder
      // to values passed from other contexts...
      if (destructure || typeof property.toISOString === 'function') {
        return property;
      }

      return property.toString();
    }

    return property;
  }
}