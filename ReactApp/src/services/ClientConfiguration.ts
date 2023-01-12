import axios from 'axios';

class ClientConfiguration {
     clientdata!: ReactClientConfiguration;

         /**
     * This function might be called multiple times upon initialization of the app.
     */
    async getData() {
        if(!this.clientdata) {
            let response = await axios.get<ReactClientConfiguration>("/reactclientconfiguration/reactclientconfiguration")
            let config = response.data
            this.clientdata = config;
        }

        return this.clientdata;
    }

    /**
     * Compare configuration properties of @param c1 to @param c2
     *
     * @param c1
     * @param c2
     */
    compareReactClientConfiguration(c1: ReactClientConfiguration, c2: ReactClientConfiguration) {
        return (
        c1.loggingEndpoint === c2.loggingEndpoint &&
        c1.includeDevRoutes === c2.includeDevRoutes);
    }
}

export interface ReactClientConfiguration {
    loggingEndpoint:        string;
    includeDevRoutes?: boolean;
}

const config = new ClientConfiguration();
export default config;
