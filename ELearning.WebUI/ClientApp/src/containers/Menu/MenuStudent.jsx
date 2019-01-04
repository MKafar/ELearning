import React, { Component } from 'react';
import { Menu } from 'semantic-ui-react';
import { Link, Route } from 'react-router-dom';

import "./MenuStudent.scss";
import StudentExercises from '../Student/StudentExercises';
import StudentCoding from '../Student/StudentCoding';
import ExerciseDetails from '../Student/ExerciseDetails';
import GradeStudents from '../Student/GradeStudents';

class MenuStudent extends Component {
    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { activeItem } = this.state

        return (
            <div className='student'>
            <Menu vertical className='studentMenu'>
                    <Menu.Item
                    as={Link}
                    to="/home"
                        name='home'
                        active={activeItem === 'home'}
                        onClick={this.handleItemClick} />
                    {/* <Menu.Item
                        as={Link}
                        to="/logout"
                        name='wyloguj'
                        active={activeItem === 'wyloguj'}
                        onClick={this.handleItemClick} /> */}
            </Menu>

            <Route path="/home" exact component={StudentExercises} />
            <Route path={'/previousexercises/:exercisePreviousDetailID'} exact component={ExerciseDetails} />
            <Route path={'/todayexercise/:exerciseTodayDetailID'} exact component={StudentCoding} />
            <Route path="/gradeothers" exact component={GradeStudents} />

          </div>  
        )
    }
}
export default MenuStudent;
