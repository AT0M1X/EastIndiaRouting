import {
    CityDto,
    PackageTypeDto,
    RouteDto,
    ProblemDetails,
    RouteIntegrationRequest,
    RouteIntegrationResponse,
    WeightClassDto,
  } from './swaggerapi/data-contracts'
  import { ContentType, HttpClient, RequestParams } from './swaggerapi/http-client'

  export class Api<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {

    getAllCities = (params: RequestParams = {}) =>
    this.request<CityDto[], ProblemDetails>({
      path: `/api/cities`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getAllPackageTypes = (params: RequestParams = {}) =>
    this.request<PackageTypeDto[], ProblemDetails>({
      path: `/api/packagetypes`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getAllRoutes = (params: RequestParams = {}) =>
    this.request<RouteDto[], ProblemDetails>({
      path: `/api/internalroutes`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getAllWeightClasses = (params: RequestParams = {}) =>
    this.request<WeightClassDto[], ProblemDetails>({
      path: `/api/weightclasses`,
      method: 'GET',
      format: 'json',
      ...params,
    })

    getRoute = (data: RouteIntegrationRequest, params: RequestParams = {}) =>
    this.request<WeightClassDto[], ProblemDetails>({
      path: `/api/weightclasses`,
      method: 'POST',
      body: data,
      format: 'json',
      ...params,
    })
  }