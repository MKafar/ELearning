import React, { Component } from 'react';

import './Admin.scss';
import MenuAdmin from '../../components/Menu/MenuAdmin';
//import AdminExercises from './AdminExercises'; 
//import AdminStudents from './AdminStudents';

class Admin extends Component {

    state = {}

    render() {

        return (
            <div className='admin'>
                <div className='menu'>
                    <MenuAdmin />
                </div>
                <div className='content'>

                </div>

            </div>
        );
    }
}

export default Admin;