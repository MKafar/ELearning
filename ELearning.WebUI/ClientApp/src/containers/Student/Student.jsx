import React, { Component } from 'react';

import './Student.scss';
import MenuStudent from '../../containers/Menu/MenuStudent';

class Student extends Component {

    state = {}

    render() {

        return (
            <div className='student'>
                <div className='menu'>
                    <MenuStudent />
                </div>
            </div>
        );
    }
}

export default Student;