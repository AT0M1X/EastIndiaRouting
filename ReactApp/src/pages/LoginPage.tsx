import Page from '../components/Page';
import React from 'react';
import {onChange} from "../utils";
import styled from "styled-components";

const RowContainer = styled.div`
  display: flex;
  flex-direction: row;
  margin: auto;
  width:100px;
  `

const FormContainer = styled.div`
  text-align: center;
  background-color: #22aaa1;
  margin: auto;
  margin-top: 30px;
  width: 60%;
  border-radius: 20px;
  padding: 20px;
  display: flex;
  flex-direction: column;
  `
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

class Login extends React.Component<any, any> {

  constructor(props: any) {
    super(props);

    this.state = {
      username: {name: 'username', values: '', required: true, error: 'Wrong credential'},
      password: {name: 'password', values: '', required: true, error: 'Wrong credential'}
    }
  }

  render() {
    const {username, password} = this.state;
    return (
        <Page headerTitle="East India Company">
          <FormContainer>
            <form onSubmit={this.onSubmit}>
              <RowContainer>
                <label>Username: </label>
                <input
                    name={username.name}
                    value={username.value}
                    onChange={this.onChange}
                    id="username"
                    type="text"
                    placeholder="Username"/>
              </RowContainer>

              <RowContainer>
                <label>Password: </label>
                <input
                    name={password.name}
                    value={password.value}
                    onChange={this.onChange}
                    id="password"
                    type="password"
                    placeholder="Password"/>
              </RowContainer>

              <Button type="submit">Login</Button>

            </form>
          </FormContainer>
        </Page>
    );
  }

  onChange = (e: any) => {
    const name = e.target.name;
    let value = e.target.value;

    onChange(this, name, value);
  }

  onSubmit = (e: any) => {
    e.preventDefault();

    const {username, password} = this.state;
    const userCredential = {
      username: username.value,
      password: password.value
    }

    let credentialPassword = "123";
    let credentialUsername = "employee";

    if (userCredential.password == credentialPassword && userCredential.username == credentialUsername) {
      window.location.href = '/booking';
    }
  }
}

export default Login;