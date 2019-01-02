import React, { Component } from 'react';
import { Button, Form, Header } from 'semantic-ui-react';


import './Login.scss';


class Login extends Component {

    state = {
        login: '',
        password: '',
    }
    changeLoginHandler = (e) => {
        this.setState({ login: e.target.value })
    }
    changePasswordHandler = (e) => {
        this.setState({ password: e.target.value })
    }
    sendCredentialsHandler = () => {
        console.log(
            "Login: " + this.state.login,
            "Hasło: "+ this.state.password
            );
            // ( this.state.login == "student" && this.state.password == "student") ? 
            // <Route path="/" exact component={Student} />  
            // : null;
            
    }


    //<div className={classes}>
    render() {
        return (
            <div className='login'>
            <Header size='large'>Zaloguj się</Header>
                <Form>
                    <Form.Field>
                        <Form.Input placeholder='Login' type='text' onChange={this.changeLoginHandler} />
                    </Form.Field>
                    <Form.Field>
                        <Form.Input placeholder='Password' type='password' onChange={this.changePasswordHandler}/>
                    </Form.Field>
                    <Button className='loginbutton' primary onClick={this.sendCredentialsHandler()}>Zaloguj</Button>
                </Form>
            </div>
        );
    }
}
export default Login;