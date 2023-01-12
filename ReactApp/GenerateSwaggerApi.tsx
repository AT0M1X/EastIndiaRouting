const { generateApi, generateTemplates } = require('swagger-typescript-api')
const path = require('path')
const fs = require('fs')

/* NOTE: all fields are optional expect one of `output`, `url`, `spec` */
generateApi({
  name: 'Api.ts',
  // set to `false` to prevent the tool from writing to disk
  output: path.resolve(process.cwd(), './src/services/swaggerapi'),
  url: 'http://localhost:6004/swagger/v1/swagger.json',
  apiclassname: 'Api',
  cleanOutput: true,
  rewrite: true,
  defaultResponseAsSuccess: false,
  generateClient: true,
  generateRouteTypes: false,
  generateResponses: true,
  modular: true,
  extractRequestParams: false,
  extractResponseBody: false,
  extractRequestBody: false,
  unwrapResponseData: false,
  enumNamesAsValues: false,
  moduleNameFirstTag: false,
  generateUnionEnums: false,
  typePrefix: '',
  typeSuffix: '',
  enumKeyPrefix: '',
  enumKeySuffix: '',
  addReadonly: false,
  extractingOptions: {
    requestBodySuffix: ['Payload', 'Body', 'Input'],
    requestParamsSuffix: ['Params'],
    responseBodySuffix: ['Data', 'Result', 'Output'],
    responseErrorSuffix: [
      'Error',
      'Fail',
      'Fails',
      'ErrorData',
      'HttpError',
      'BadResponse',
    ],
  },
  /** allow to generate extra files based with this extra templates, see more below */
  fixInvalidTypeNamePrefix: 'Type',
  fixInvalidEnumKeyPrefix: 'Value',
  codeGenConstructs: (constructs) => ({
    ...constructs,
    RecordType: (key, value) => `MyRecord<key, value>`,
  }),
  primitiveTypeConstructs: (constructs) => ({
    ...constructs,
    string: {
      'date-time': 'Date',
    },
  }),
})
  .then(({ files, configuration }) => {
    files.forEach(({ content, name }) => {
      fs.writeFile(path, content)
    })
  })
  .catch((e) => console.error(e))
