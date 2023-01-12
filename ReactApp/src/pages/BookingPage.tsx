import React, { FunctionComponent, ReactNode, useEffect, useState } from "react";
import Page from "../components/Page";
import FrontServiceApi from "../services/FrontServiceApi";
import { PackageTypeDto, RouteIntegrationRequest } from "../services/swaggerapi/data-contracts";
import PackageTypeDropdown from "../components/WhatComponents/PackageTypeDropdown";
import PackageInfoInput from "../components/WhatComponents/PackageInfoInput";
import WhatComponent from "../components/WhatComponent";

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

  const handleChange = (event) => {

  }

  const handlePackageInfoChange = (e) => {
    setRouteRequest({ ...routeRequest, [e.target.name]: e.target.value })
    console.info(routeRequest)
  }

  return (
    <Page headerTitle={"Make a Package Delivery"}>
      <WhatComponent PackageTypes={packageTypes} handleInputChange={handlePackageInfoChange} onSelectClick={handleChange} />
    </Page>)
};

export default BookingPage;
