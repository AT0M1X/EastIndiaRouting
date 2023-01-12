import React, { FunctionComponent, ReactNode, useEffect, useState } from "react";
import Page from "../components/Page";
import FrontServiceApi from "../services/FrontServiceApi";
import { PackageTypeDto, RouteIntegrationRequest } from "../services/swaggerapi/data-contracts";
import PackageTypeDropdown from "../components/PackageTypeDropdown";

const BookingPage: FunctionComponent = () => {
  const [packageTypes, setPackageTypes] = useState<PackageTypeDto[]>([])
  const [routeRequest, setRouteRequest] = useState<RouteIntegrationRequest>()

  const setDefaultRequest = () => {
    setRouteRequest({
      ...routeRequest,
      from: null,
      to: null,
      type: null,
      arrivalTime: null,
      currency: null,
      weight: 0,
      height: 0,
      width: 0,
      depth: 0,
      recommended: false
    })
  }

  useEffect(() => {
    const promise = FrontServiceApi.getAllPackageTypes()
    promise
      .then((packageTypesDto) => {
        setPackageTypes(packageTypesDto.data)
      })
      .catch((reason) => {
        console.log(reason)
      })

    setDefaultRequest()
  }, [])

  return (
    <Page headerTitle={"Make a Package Delivery"}>
      <PackageTypeDropdown PackageTypes={packageTypes}/>
    </Page>)
};

export default BookingPage;
