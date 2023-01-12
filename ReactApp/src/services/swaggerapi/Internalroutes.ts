/* eslint-disable */
/* tslint:disable */
/*
 * ---------------------------------------------------------------
 * ## THIS FILE WAS GENERATED VIA SWAGGER-TYPESCRIPT-API        ##
 * ##                                                           ##
 * ## AUTHOR: acacode                                           ##
 * ## SOURCE: https://github.com/acacode/swagger-typescript-api ##
 * ---------------------------------------------------------------
 */

import { RouteDto } from "./data-contracts";
import { HttpClient, RequestParams } from "./http-client";

export class Internalroutes<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags FrontEnd
   * @name GetInternalRoutes
   * @request GET:/internalroutes
   * @response `200` `(RouteDto)[]` Success
   */
  getInternalRoutes = (params: RequestParams = {}) =>
    this.request<RouteDto[], any>({
      path: `/internalroutes`,
      method: "GET",
      format: "json",
      ...params,
    });
}
