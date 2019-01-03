/* eslint-disable no-unused-expressions */
import React, { Component } from 'react';
import { Button, Form, Header } from 'semantic-ui-react';
import { Route } from 'react-router-dom';

import './Login.scss';
import Admin from '../Admin/Admin';
import Student from '../Student/Student';

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

            this.state.login === "admin" && this.state.password === "admin" ? 
             console.log(this.props) 
             : null 
             
             //this.props.history.push('/admin/')
             //this.props.history.push('/student/');
            
    }
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
                    <Button className='loginbutton' primary onClick={this.sendCredentialsHandler}>Zaloguj</Button>
                </Form>

                <Route path="/admin" exact component={Admin} />
                <Route path="/student" exact component={Student} />

            </div>
        );
    }
}
export default Login;