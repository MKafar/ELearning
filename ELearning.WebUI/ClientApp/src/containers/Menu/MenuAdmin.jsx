import React, { Component } from 'react';
import { Menu } from 'semantic-ui-react';
import { Link, Route, Switch } from 'react-router-dom';

import "./MenuAdmin.scss";


import AdminExercises from '../Admin/AdminExercises';
import AdminStudents from '../Admin/AdminStudents';
import AdminHome from '../Admin/AdminHome';
import AdminSubjects from '../Admin/AdminSubjects';
import StudentDetails from '../Admin/StudentDetails';
import StudentDetailsAssignment from '../Admin/StudentDetailsAssignment';
import ExerciseVariant from '../Admin/ExerciseVariant';
import ExerciseVariantDetails from '../Admin/ExerciseVariantDetails';
import SubjectGroups from '../Admin/SubjectGroups';
import GroupSections from '../Admin/GroupSections';
import Admin from '../Admin/Admin';
import Student from '../Student/Student';

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
                        to="/subject"
                        name='przedmiot'
                        active={activeItem === 'przedmiot'}
                        onClick={this.handleItemClick} />
                    <Menu.Item
                        as={Link}
                        to="/students"
                        name='student'
                        active={activeItem === 'student'}
                        onClick={this.handleItemClick} />
                </Menu>
                
                <Switch>
                    <Route path="/admin" exact component={AdminHome} />
                    <Route path="/home" exact component={AdminHome} />
                    <Route path="/exercises" exact component={AdminExercises} />
                    <Route path="/subject" exact component={AdminSubjects} />
                    <Route path={'/subject/:subjectID'} exact component={SubjectGroups} />
                    <Route path={'/subject/:subjectID/:groupSectionsID'} exact component={GroupSections} />
                    <Route path="/students" exact component={AdminStudents} />
                    <Route path={'/students/:studentDetailsID'} exact component={StudentDetails} />
                    <Route path={'/students/:studentDetailsID/:studentDetailsExerciseID'} exact component={StudentDetailsAssignment} />
                    <Route path={'/exercises/:exerciseDetailsID'} exact component={ExerciseVariant} />
                    <Route path={'/exercises/:exerciseDetailsID/:exerciseVariantID'} exact component={ExerciseVariantDetails} />
                </Switch>
            </div>
        )
    }
}
export default MenuAdmin;
