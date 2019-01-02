import React, { Component } from 'react';

import './Student.scss';
import MenuStudent from '../../containers/Menu/MenuStudent';
import StudentExercises from './StudentExercises';

class Student extends Component {

    state = {}

    render() {

        return (
            <div className='student'>
                <div className='menu'>
                    <MenuStudent />
                </div>
                <StudentExercises />
            </div>
        );
    }
}

export default Student;