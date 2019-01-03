import React, { Component } from 'react';
import { Menu } from 'semantic-ui-react';
import { Link, Route } from 'react-router-dom';

import "./MenuAdmin.scss";


import AdminExercises from '../Admin/AdminExercises';
import AdminStudents from '../Admin/AdminStudents';
import AdminHome from '../Admin/AdminHome';
import AdminSubjects from '../Admin/AdminSubjects';
import StudentDetails from '../Admin/StudentDetails';
import StudentDetailsAssignment from '../Admin/StudentDetailsAssignment';
import ExerciseVariant from '../Admin/ExerciseVariant';
import ExerciseVariantDetails from '../Admin/ExerciseVariantDetails';

class MenuAdmin extends Component {
    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render() {
        const { activeItem } = this.state;

        return (
            <div className='admin'>
                <Menu vertical className='adminMenu'>
                    <Menu.Item
                        as={Link}
                        to="/home"
                        name='home'
                        active={activeItem === 'home'}
                        onClick={this.handleItemClick} />
                    <Menu.Item
                        as={Link}
                        to="/exercises"
                        name='zadanie'
                        active={activeItem === 'zadanie'}
                        onClick={this.handleItemClick} />

                    <Menu.Item
                        as={Link}
                        to="/laboratory"
                        name='laboratorium'
                        active={activeItem === 'laboratorium'}
                        onClick={this.handleItemClick} />
                    <Menu.Item
                        as={Link}
                        to="/students"
                        name='student'
                        active={activeItem === 'student'}
                        onClick={this.handleItemClick} />
                </Menu>

                <Route path="/home" exact component={AdminHome} />
                <Route path="/exercises" exact component={AdminExercises} />
                <Route path="/laboratory" exact component={AdminSubjects} />
                <Route path="/students" exact component={AdminStudents} />
                <Route path={'/students/:studentDetailsID'} exact component={StudentDetails} />
                <Route path={'/students/:studentDetailsID/:studentDetailsExerciseID'} exact component={StudentDetailsAssignment} />
                <Route path={'/exercises/:exerciseDetailsID'} exact component={ExerciseVariant} />
                <Route path={'/exercises/:exerciseDetailsID/:exerciseVariantID'} exact component={ExerciseVariantDetails} />


            </div>
        )
    }
}
export default MenuAdmin;
