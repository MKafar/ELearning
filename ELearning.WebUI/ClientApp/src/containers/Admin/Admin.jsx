import React, { Component } from 'react';

import './Admin.scss';
import MenuAdmin from '../../components/Menu/MenuAdmin';
import AdminExerciseDetails from './AdminExerciseDetails';
import AdminExercises from './AdminExercises'; 
import AdminStudents from './AdminStudents';
import AdminHome from './AdminHome';

class Admin extends Component {

    state = {}

    render() {

        return (
            <div className='admin'>
                <div className='menu'>
                    <MenuAdmin />
                </div>
                <div className='content'>
                    <AdminHome />
                </div>

            </div>
        );
    }
}

export default Admin;