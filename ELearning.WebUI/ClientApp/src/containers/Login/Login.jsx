import React, { Component } from 'react';
import { Button, Form } from 'semantic-ui-react';

import './Login.scss';

class Login extends Component {

    state = {

    }


    //<div className={classes}>
    render() {
        return (
            <div className='login'>
                <Form>
                    <Form.Field>
                        <Form.Input placeholder='Login' type='text' />
                    </Form.Field>
                    <Form.Field>
                        <Form.Input placeholder='Password' type='password' />
                    </Form.Field>
                    <Button className='loginbutton' primary>Login</Button>
                </Form>
            </div>
        );
    }
}
export default Login;