import axios from 'axios';
import { LogError } from './ErrorService';

const ApiService = <T>(url: string, method: string = 'get', data: object | undefined = undefined, headers: object | undefined = undefined, skipLogging: boolean = false): Promise<T> => {
    const callApi = async (): Promise<any> => {

            return _callApi(method, data, headers, skipLogging).catch(error => {
                throw error;
            });
    }

    const _callApi = async (method: string, data: object | undefined, customHeaders: object | undefined = undefined, skipLogging: boolean) => {
        const headers = customHeaders ?? {
   //         Authorization: 'Bearer ' + token
        };
        const finalUrl = (url.startsWith('http:') || url.startsWith('https:')) ? url : `/${url}`;
        try {
            const response = method.toLowerCase() === 'post' 
                ? await axios.post<T>(finalUrl, 
                    data,
                    {
                        headers: headers,
                        withCredentials: true
                    })
                : method.toLowerCase() === 'put'
                    ? await axios.put<T>(finalUrl, 
                        data,
                        {
                            headers: headers,
                            withCredentials: true
                        })
                    : method.toLowerCase() === 'patch'
                        ? await axios.patch<T>(finalUrl, 
                            data,
                            {
                                headers: headers,
                                withCredentials: true
                            })
                        : method.toLowerCase() === 'delete'
                            ? await axios.delete<T>(finalUrl, 
                                {
                                    headers: headers,
                                    withCredentials: true
                                })
                            : await axios.request<T>({
                                url:  finalUrl,
                                headers: headers,
                                withCredentials: true
                            });

            return response.data;
        } catch (error: any) {
            if (!skipLogging) {
                LogError(error.stack ? error.stack : error.message);
            }
            throw error;
        }
    }

    return callApi();
}


export default ApiService;