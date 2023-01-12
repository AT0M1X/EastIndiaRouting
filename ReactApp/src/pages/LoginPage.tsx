import Page from '../components/Page';
import React from 'react';
import {onChange, accessGranted} from '../utils'

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
                <div className="container page-container">
                    <form onSubmit={this.onSubmit} className="login-container">
                        <div className="form-section">
                            <label>Username: </label>
                            <input
                                name={username.name}
                                value={username.value}
                                onChange={this.onChange}
                                id="username"
                                type="text"
                                placeholder="Username"/>
                        </div>

                        <div className="form-section">
                            <label>Password: </label>
                            <input
                                name={password.name}
                                value={password.value}
                                onChange={this.onChange}
                                id="password"
                                type="password"
                                placeholder="Password"/>
                        </div>

                        <button type="submit">Login</button>

                    </form>
                </div>

                <p className="username"></p>
                <p className="password"></p>
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

        console.log(userCredential);

        if (true) {
            accessGranted();
        }
    }
}
export default Login;
