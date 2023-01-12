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

import { CityDto } from "./data-contracts";
import { HttpClient, RequestParams } from "./http-client";

export class Cities<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags FrontEnd
   * @name GetCities
   * @request GET:/cities
   * @response `200` `(CityDto)[]` Success
   */
  getCities = (params: RequestParams = {}) =>
    this.request<CityDto[], any>({
      path: `/cities`,
      method: "GET",
      format: "json",
      ...params,
    });
}
