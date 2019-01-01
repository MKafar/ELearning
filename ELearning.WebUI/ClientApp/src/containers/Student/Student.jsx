import React, { Component } from 'react';

import './Student.scss';
import ExerciseDetails from './ExerciseDetails';
import StudentCoding from './StudentCoding';
import MenuStudent from '../../components/Menu/MenuStudent';
import GradeStudents from './GradeStudents';
import StudentExercises from './StudentExercises';


class Student extends Component {

    state = {}

    render() {

        return (
            <div className='student'>
                <div className='menu'>
                    <MenuStudent />
                </div>
                <StudentCoding />
            </div>
        );
    }
}

export default Student;