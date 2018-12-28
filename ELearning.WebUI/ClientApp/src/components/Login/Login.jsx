import React from 'react';
import { Input, Button } from 'semantic-ui-react';

import './Login.scss';

const Login = () => (
    <div className="login">
        <div className='loginfield'>
            <Input placeholder='Login' />
            <Input placeholder='Password' />
            <Button className = 'loginbutton' primary>Login</Button>
        </div>
        
    </div>

)

export default Login;