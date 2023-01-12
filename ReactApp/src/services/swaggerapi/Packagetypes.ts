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

import { PackageTypeDto } from "./data-contracts";
import { HttpClient, RequestParams } from "./http-client";

export class Packagetypes<SecurityDataType = unknown> extends HttpClient<SecurityDataType> {
  /**
   * No description
   *
   * @tags FrontEnd
   * @name GetPackageTypes
   * @request GET:/packagetypes
   * @response `200` `(PackageTypeDto)[]` Success
   */
  getPackageTypes = (params: RequestParams = {}) =>
    this.request<PackageTypeDto[], any>({
      path: `/packagetypes`,
      method: "GET",
      format: "json",
      ...params,
    });
}
