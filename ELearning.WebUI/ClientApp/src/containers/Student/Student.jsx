import React, { Component } from 'react';
import { Route, withRouter, Switch } from 'react-router-dom';

import './Student.scss';
import MenuStudent from '../../containers/Menu/MenuStudent';
import StudentExercises from './StudentExercises';
import StudentCoding from './StudentCoding';
import ExerciseDetails from './ExerciseDetails';
import GradeStudents from './GradeStudents';

class Student extends Component {

    render() {
        const user = this.props.user;
        console.log("Student",this.props);
        

        return (
            <div className='student'>
                <div className='menu'>
                    <MenuStudent onClearUser={this.props.onClearUser} />
                </div>
                <Switch>
                    <Route path="/student" exact component={() => <StudentExercises user={user} />} />
                    <Route path={'/student/previousexercises/:previousAssignmentID'} exact component={ExerciseDetails} />
                    <Route path={'/student/todayexercise/:exerciseTodayDetailID'} exact component={StudentCoding} />
                    <Route path={'/student/gradeothers/:exerciseTodayDetailID'} exact component={GradeStudents} />
                </Switch>

            </div>
        );
    }
}

export default withRouter(Student);