/* eslint-disable no-unused-expressions */
import React, { Component } from 'react';
import { Button, Form, Header } from 'semantic-ui-react';
import { Route, Link } from 'react-router-dom';
import axios from '../../axios';

import './Login.scss';
import Admin from '../Admin/Admin';
import Student from '../Student/Student';

class Login extends Component {

    state = {
        login: '',
        password: '',
        userData: null
    }
    changeLoginHandler = (e) => {
        this.setState({ login: e.target.value })
    }
    changePasswordHandler = (e) => {
        this.setState({ password: e.target.value })
    }
    sendCredentialsHandler = () => {

        axios.post('/api/Auth/Login', {
            login: this.state.login,
            password: this.state.password
        }).then(response => {
            //console.log(response.data);
            this.setState({userData: response.data});


        }).catch(error => {
            console.log(error.response);
        })

          
           
    }

    // <Link to='admin'>Admin</Link>
    // <Link to='student'>Student</Link>

    //this.props.history.push('/admin/')
     //this.props.history.push('/student/');
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

            </div>
        );
    }
}
export default Login;