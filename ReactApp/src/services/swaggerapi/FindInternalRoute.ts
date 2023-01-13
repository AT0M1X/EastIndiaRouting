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

import { ProblemDetails } from "./data-contracts";
import { HttpClient, RequestParams } from "./http-client";

export class FindInternalRoute<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags FrontEnd
   * @name GetInternalRoute
   * @request GET:/findInternalRoute
   * @response `200` `void` Success
   * @response `204` `void` Success
   * @response `400` `ProblemDetails` Bad Request
   */
  getInternalRoute = (
    query?: {
      from?: string;
      to?: string;
      /** @format int32 */
      weight?: number;
      /** @format int32 */
      length?: number;
      /** @format int32 */
      width?: number;
      /** @format int32 */
      height?: number;
      packageType?: string;
      /** @format date-time */
      arrivalTime?: Date;
      currency?: string;
      recommended?: boolean;
    },
    params: RequestParams = {},
  ) =>
    this.request<void, ProblemDetails>({
      path: `/findInternalRoute`,
      method: "GET",
      query: query,
      ...params,
    });
}
