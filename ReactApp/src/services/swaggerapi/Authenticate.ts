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

import { HttpClient, RequestParams } from "./http-client";

export class Authenticate<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags FrontEnd
   * @name Authenticate
   * @request GET:/authenticate
   * @response `200` `boolean` Success
   */
  authenticate = (
    query: {
      Username: string;
      Password: string;
    },
    params: RequestParams = {},
  ) =>
    this.request<boolean, any>({
      path: `/authenticate`,
      method: "GET",
      query: query,
      format: "json",
      ...params,
    });
}
