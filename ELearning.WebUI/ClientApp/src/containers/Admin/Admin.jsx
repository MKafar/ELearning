import React, { Component } from 'react';

import './Admin.scss';
import MenuAdmin from '../../components/Menu/MenuAdmin';
import AdminExerciseDetails from './AdminExerciseDetails';
import AdminExercises from './AdminExercises'; 
import AdminStudents from './AdminStudents';
import AdminHome from './AdminHome';
import ExerciseVariant from './ExerciseVariant';
import ExerciseVariantDetails from './ExerciseVariantDetails';
import AdminSubjects from './AdminSubjects';
import StudentDetails from './StudentDetails';

class Admin extends Component {

    state = {}

    render() {

        return (
            <div className='admin'>
                <div className='menu'>
                    <MenuAdmin />
                </div>
                <div className='content'>
                    <StudentDetails />
                </div>

            </div>
        );
    }
}

export default Admin;