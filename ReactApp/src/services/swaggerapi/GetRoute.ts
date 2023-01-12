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

import { ProblemDetails, RouteIntegrationRequest, RouteIntegrationResponse } from "./data-contracts";
import { ContentType, HttpClient, RequestParams } from "./http-client";

export class GetRoute<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags Integration
   * @name GetRoute
   * @request POST:/GetRoute
   * @response `200` `RouteIntegrationResponse` Success
   * @response `204` `void` No Content
   * @response `400` `ProblemDetails` Bad Request
   */
  getRoute = (data: RouteIntegrationRequest, params: RequestParams = {}) =>
    this.request<RouteIntegrationResponse, ProblemDetails>({
      path: `/GetRoute`,
      method: "POST",
      body: data,
      type: ContentType.Json,
      format: "json",
      ...params,
    });
}
