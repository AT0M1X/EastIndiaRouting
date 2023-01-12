import React, {
  FunctionComponent,
  ReactNode,
  useEffect,
  useState,
} from "react";
import Page from "../components/Page";
import FrontServiceApi from "../services/FrontServiceApi";
import {
  PackageTypeDto,
  RouteIntegrationRequest,
} from "../services/swaggerapi/data-contracts";
import styled, { css } from "styled-components";
import WhatComponent from "../components/WhatComponent";
import WhoComponent from "../components/WhoComponent";

interface CustomerInfo {
  Customer?: string | undefined
  Phone?: string | undefined
  EMail?: string | undefined
}

const BookingPage = () => {
  const [packageTypes, setPackageTypes] = useState<PackageTypeDto[]>([]);
  const [routeRequest, setRouteRequest] = useState<RouteIntegrationRequest>();
  const [title, setTitle] = useState<string>("Specify The Parameters of Your Parcel");
  const [stage, setStage] = useState<number>(1);
  const [customerInfo, setCustomerInfo] = useState<CustomerInfo>();

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
      recommended: false,
    });

    setCustomerInfo({
      ...customerInfo,
      Customer: "",
      Phone: "",
      EMail: ""
    });
  };


  useEffect(() => {
    const promise = FrontServiceApi.getAllPackageTypes();
    promise
      .then((packageTypesDto) => {
        setPackageTypes(packageTypesDto.data);
      })
      .catch((reason) => {
        console.log(reason);
      });

    setDefaultRequest();
  }, []);

  useEffect(() => {
    console.info(routeRequest)
    switch(stage){
      case 1:
        setTitle("Specify The Parameters of Your Parcel")
        return
      case 2:
        setTitle("Choose a Starting and Destination Point")
        return
      case 3:
        setTitle("Choose a Preferable Route")
         return
      case 4:
        setTitle("Customer Information")
        return
      case 5:
        setTitle("Order Summary")
        return
      default:
    }
    
  }, [stage]);

  const handleChange = (event) => {
    setRouteRequest({ ...routeRequest, ["type"]: event.target.value })
  }

  const handlePackageInfoChange = (e) => {
    setRouteRequest({ ...routeRequest, [e.target.name]: e.target.value })
  }

  const handleCustomerInfoChange = (e) => {
    setCustomerInfo({...customerInfo, [e.target.name]: e.target.value })
  }

  const handelStage = (value: number) => {
    const newStage = stage + value;
    if(newStage > 0 && newStage < 6)
    {
      setStage(newStage)
    }
  }

  return (
    <Page headerTitle={"Make a Package Delivery"}>
      <BookingView>
        <Banner>
          <div>{title}</div>
        </Banner>
        <MainView>
          { stage == 1 &&
            <WhatComponent InputData={routeRequest!} PackageTypes={packageTypes} handleInputChange={handlePackageInfoChange} onSelectClick={handleChange} />
          }
          { stage == 4 &&
            <WhoComponent Customer={customerInfo!} handleInputChange={handleCustomerInfoChange} />
          }
        </MainView>
        <ButtonContainer>
          <Button
            onClick={() => {
              handelStage(-1);
            }}
          >
            Previous
          </Button>
          <Button onClick={() => {
              handelStage(1);
            }}>Next</Button>
        </ButtonContainer>
      </BookingView>
    </Page>
  );
};

const BookingView = styled.div`
  text-align: center;
  background-color: #22aaa1;
  margin: auto;
  margin-top: 30px;
  width: 60%;
  border-radius: 20px;
  padding: 20px;
  display: flex;
  flex-direction: column;
`;

const MainView = styled.div`
  height: 400px;
`;

const Button = styled.button`
  background-color: #ffffff;
  border-radius: 50px;
  border: 2px solid #ffffff;
  color: black;
  margin: 0.5em 1em;
  padding: 0.25em 1em;
  hight: 50px;
  width: 150px;
`;

const Banner = styled.header`
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 10px;
  background: #000;
  border-radius: 10px;
  width: 70%;
  margin: auto;
  background-color: #3c3c3c;

  div {
    font-weight: 400;
    z-index: 1;
    color: #ffffff;
    font-size: 1.2rem;
  }
`;

const ButtonContainer = styled.div`
  display: flex;
  height: 40%;
  justify-content: space-between;
`;

export default BookingPage;
