import React, { FunctionComponent } from "react";
import Page from "../components/Page";
import styled, { css } from "styled-components";
import logo from "../assets/img/logo_2.png";

const HomePage: FunctionComponent = () => {
  return (
    <Page headerTitle="East India Company">
      <LogoContainer>
        <Logo></Logo>
      </LogoContainer>
      <BottomContainer>
        <Banner>
          <div>The Best Parcel Delivery Service in Africa</div>
        </Banner>
      </BottomContainer>
    </Page>
  );
};

const Button = styled.button`
  background: transparent;
  border-radius: 3px;
  border: 2px solid palevioletred;
  color: palevioletred;
  margin: 0.5em 1em;
  padding: 0.25em 1em;
`;

const LogoContainer = styled.div`
  text-align: center;
  background-color: #22aaa1;
  margin: auto;
  margin-top: 30px;
  width: 400px;
  border-radius: 20px;
  padding: 20px;
`;

const BottomContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  position: absolute;
  width: 100%;
  height: 20%;
  background-color: #22aaa1;
  bottom: 0;
`;

const Logo = styled.div`
  background-image: url(${logo});
  background-repeat: no-repeat;
  width: 294px;
  height: 296px;
  background-size: cover;
  margin: auto;
`;

const HomeContainer = styled.div`
  display: flex;
`;

const Banner = styled.header`
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 10px;
  background: #000;
  width: 100%;
  margin: auto;
  background-color: #3c3c3c;

  div {
    font-weight: 500;
    z-index: 1;
    color: #ffffff;
    font-size: 1.3rem;
  }
`;

export default HomePage;
