import React, { FunctionComponent } from "react";
import Page from "../components/Page";
import styled, { css } from "styled-components";
import logo from "../assets/img/logo_2.png";
import { useHistory } from "react-router-dom";

const HomePage: FunctionComponent = () => {
  const history = useHistory();

  function navigateToLogin() {
    history.push("/login");
  }
  return (
    <Page headerTitle="East India Company">
      <LogoContainer>
        <Logo></Logo>
      </LogoContainer>
      <BottomContainer>
        <Banner>
          <div>The Best Parcel Delivery Service in Africa</div>
        </Banner>
        <ButtonContainer>
          <Button
            onClick={() => {
              console.log("asd");
            }}
          >
            Sign in To Book
          </Button>
          <Button onClick={navigateToLogin}>Login</Button>
        </ButtonContainer>
      </BottomContainer>
    </Page>
  );
};

const Button = styled.button`
  background-color: #ffffff;
  border-radius: 50px;
  border: 2px solid #ffffff;
  color: black;
  margin: 0.5em 1em;
  padding: 0.25em 1em;
  hight: 50px;
  width: 250px;
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
  flex-direction: column;
`;

const Logo = styled.div`
  background-image: url(${logo});
  background-repeat: no-repeat;
  width: 294px;
  height: 296px;
  background-size: cover;
  margin: auto;
`;

const ButtonContainer = styled.div`
  display: flex;
  height: 40%;
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
