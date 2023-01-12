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

export interface CityDto {
  /** @format int32 */
  id: number;
  /** @minLength 1 */
  name: string;
}

export interface PackageTypeDto {
  /** @format int32 */
  id: number;
  /** @minLength 1 */
  name: string;
}

export interface ProblemDetails {
  type?: string | null;
  title?: string | null;
  /** @format int32 */
  status?: number | null;
  detail?: string | null;
  instance?: string | null;
  [key: string]: any;
}

export interface RouteDto {
  /** @format int32 */
  id: number;
  /** @minLength 1 */
  from: string;
  /** @minLength 1 */
  to: string;
  /** @format int32 */
  time: number;
  /** @format int32 */
  segments: number;
  /** @format int32 */
  fromId: number;
  /** @format int32 */
  toId: number;
}

export interface RouteIntegrationRequest {
  from?: string | null;
  to?: string | null;
  type?: string | null;
  arrivalTime?: string | null;
  currency?: string | null;
  /** @format int32 */
  weight?: number;
  /** @format int32 */
  height?: number;
  /** @format int32 */
  width?: number;
  /** @format int32 */
  depth?: number;
  recommended?: boolean;
}

export interface RouteIntegrationResponse {
  correlationID?: string | null;
  /** @format int32 */
  cost?: number;
  /** @format int32 */
  time?: number;
}

export interface WeightClassDto {
  /** @format int32 */
  id: number;
  /** @format int32 */
  minimumWeight: number;
  /** @format int32 */
  maximumWeight: number;
  /** @format int32 */
  price: number;
}
