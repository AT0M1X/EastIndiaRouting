import { FunctionComponent, useState } from "react";
import { ReactComponent as LogoSvg } from "../assets/img/logo.svg";
import { useLocation, Link } from "react-router-dom";
import { MenuSetup, Side } from "../Routing";
import styled, { css } from "styled-components";
import logo from "/Code/Github/EastIndiaRouting/ReactApp/src/assets/img/logo.png";

type props = {
  title: string;
};

const HeaderComponent = ({ title = "East India Company" }: props) => {
  //const [title, setCount] = useState(title);

  return (
    <div>
      <Header>
        <Logo />
        <div>{title}</div>
      </Header>
      <Line />
    </div>
  );
};

const Header = styled.header`
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 10px;
  background: #000;
  width: 60%;
  margin: auto;
  border-radius: 20px;
  background-color: #3c3c3c;

  div {
    font-weight: 1000;
    z-index: 1;
    color: #ffffff;
    font-size: 2rem;
  }
`;

const Line = styled.div`
  display: block;
  height: 12px;
  width: 80%;
  border: 0;
  border-bottom: 2px solid black;
  margin: auto;
}
`;

const Logo = styled.div`
  background-image: url(${logo});
  background-repeat: no-repeat;
  width: 50px;
  height: 49.4px;
  background-size: cover;
  margin-right: 10px;
`;

export default HeaderComponent;
