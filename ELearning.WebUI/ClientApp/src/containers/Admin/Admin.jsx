import React, { Component } from 'react';
import { Route, Switch } from 'react-router-dom';
import './Admin.scss';
import MenuAdmin from '../../containers/Menu/MenuAdmin';
import AdminExercises from './AdminExercises';
import AdminStudents from './AdminStudents';
import AdminHome from './AdminHome';
import AdminSubjects from './AdminSubjects';
import StudentDetails from './StudentDetails';
import StudentDetailsAssignment from './StudentDetailsAssignment';
import ExerciseVariant from './ExerciseVariant';
import ExerciseVariantDetails from './ExerciseVariantDetails';
import SubjectGroups from './SubjectGroups';
import GroupSections from './GroupSections';

class Admin extends Component {
    render() {
        const user = this.props.user;
        return (
            <div className='admin'>
                <div className='menu'>
                    <MenuAdmin onClearRoles={this.props.onClearUser} />
                </div>
                <Switch>
                    <Route path="/admin" exact component={() => <AdminHome user={user} />} />
                    <Route path="/admin/exercises" exact component={AdminExercises} />
                    <Route path="/admin/subject" exact component={AdminSubjects} />
                    <Route path={'/admin/subject/:subjectID'} exact component={SubjectGroups} />
                    <Route path={'/admin/subject/:subjectID/:groupSectionsID'} exact component={GroupSections} />
                    <Route path="/admin/students" exact component={AdminStudents} />
                    <Route path={'/admin/students/:studentDetailsID'} exact component={StudentDetails} />
                    <Route path={'/admin/students/:studentDetailsID/:studentDetailsExerciseID'} exact component={StudentDetailsAssignment} />
                    <Route path={'/admin/exercises/:exerciseDetailsID'} exact component={ExerciseVariant} />
                    <Route path={'/admin/exercises/:exerciseDetailsID/:exerciseVariantID'} exact component={ExerciseVariantDetails} />
                </Switch>
            </div>
        );
    }
}
export default Admin;