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
    this.request<WeightClassDto[], ProblemDetails>({
      path: `/GetRoute`,
      method: 'POST',
      body: data,
      format: 'json',
      ...params,
    })
  }