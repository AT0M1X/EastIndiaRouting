import {
    CityDto,
    PackageTypeDto,
    RouteDto,
    ProblemDetails,
    RouteIntegrationRequest,
    RouteIntegrationResponse,
    WeightClassDto,
    RouteResult,
  } from './swaggerapi/data-contracts'
  import { ContentType, HttpClient, RequestParams } from './swaggerapi/http-client'

  export class Api<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {

    getAllCities = (params: RequestParams = {}) =>
    this.request<CityDto[], ProblemDetails>({
      path: `/cities`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getAllPackageTypes = (params: RequestParams = {}) =>
    this.request<PackageTypeDto[], ProblemDetails>({
      path: `/packagetypes`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getAllRoutes = (params: RequestParams = {}) =>
    this.request<RouteDto[], ProblemDetails>({
      path: `/internalroutes`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getAllWeightClasses = (params: RequestParams = {}) =>
    this.request<WeightClassDto[], ProblemDetails>({
      path: `/weightclasses`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getRoute = (data: RouteIntegrationRequest, params: RequestParams = {}) =>
    this.request<RouteIntegrationResponse, ProblemDetails>({
      path: `/GetRoute`,
      method: 'POST',
      body: data,
      format: 'json',
      ...params,
    })

    findRoute = (from: string, to: string, weight: number, length: number, width: number, height: number, packageType: string, arrivalTime:string, currency: string, params: RequestParams = {}) =>
    this.request<RouteResult, ProblemDetails>({
      path: `/findInternalRoute?from=${from}&to=${to}&weight=${weight}&length=${length}&width=${width}&height=${height}&packageType=${packageType}&arrivalTime=${arrivalTime}&currency=${currency}&recommended=false`,
      method: 'Get',
      format: 'json',
      ...params,
    })
  }