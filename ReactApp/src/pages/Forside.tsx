import React, { FunctionComponent } from "react";
import Page from "../components/Page";
import styled, { css } from "styled-components";

const Forside: FunctionComponent = () => {
  return (
    <Page>
      <Container>
        <Button>Normal Button</Button>
        <Button primary>Primary Button</Button>
      </Container>
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

const Container = styled.div`
  text-align: center;
`;

export default Forside;
