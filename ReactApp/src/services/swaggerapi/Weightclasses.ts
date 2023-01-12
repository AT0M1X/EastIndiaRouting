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

import { WeightClassDto } from "./data-contracts";
import { HttpClient, RequestParams } from "./http-client";

export class Weightclasses<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags FrontEnd
   * @name GetWeightClasses
   * @request GET:/weightclasses
   * @response `200` `(WeightClassDto)[]` Success
   */
  getWeightClasses = (params: RequestParams = {}) =>
    this.request<WeightClassDto[], any>({
      path: `/weightclasses`,
      method: "GET",
      format: "json",
      ...params,
    });
}
