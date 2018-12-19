import React from 'react';
import { Input } from 'semantic-ui-react';

import './Login.scss';

const LoginInput = () => (
    <div className="login">
        <div className='loginfield'>
            <Input placeholder='Login' />
            <Input placeholder='Password' />
        </div>


    </div>

)

export default LoginInput;