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
import PackageTypeDropdown from "../components/PackageTypeDropdown";
import styled, { css } from "styled-components";

const BookingPage = () => {
  const [packageTypes, setPackageTypes] = useState<PackageTypeDto[]>([]);
  const [routeRequest, setRouteRequest] = useState<RouteIntegrationRequest>();
  const [title, setTitle] = useState<string>("Title");

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

  const handleChange = (event) => {};

  return (
    <Page headerTitle={"Make a Package Delivery"}>
      <BookingView>
        <Banner>
          <div>{title}</div>
        </Banner>
        <MainView></MainView>
        <ButtonContainer>
          <Button
            onClick={() => {
              console.log("asd");
            }}
          >
            Previous
          </Button>
          <Button>Next</Button>
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
