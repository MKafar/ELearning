import React, { Component } from 'react';
import { Button, Form, Header } from 'semantic-ui-react';
import { withRouter } from 'react-router-dom';
import axios from '../../axios';
import { hasRole } from '../../auth';

import './Login.scss';

class Login extends Component {

    state = {
        login: '',
        password: '',
        userData: [],
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
            console.log("Login successful response.data:", response.data);
            this.setState({userData: [response.data.role]});
            this.redirectDependingOnRole(response.data.role);
        }).catch(error => {
            console.log("Login error.response:", error.response);
        })     
    }

    redirectDependingOnRole = (userRole) => {
        const user = {
            roles: [userRole]
        }
        
        let hasRoleStudent = hasRole(user, ['Student']);
        let hasRoleAdmin = hasRole(user, ['Administrator']);

        hasRoleStudent ? this.props.history.push('/student/') : hasRoleAdmin ? this.props.history.push('/admin/') : this.props.history.push('/');
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

            </div>
        );
    }
}
export default withRouter(Login);