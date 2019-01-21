import React, { Component } from 'react';
import { Header, Dropdown, Button } from 'semantic-ui-react';
import axios from '../../axios';
import {withRouter} from 'react-router';

import './GradeStudents.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import Grade from '../../components/Grades/Grade';


class GradeStudents extends Component {

    state = {
        //value to musi być assignment id tego studenta ktorego oceniasz
        studentOptions: [],
        selectedStudent: null,
        evaluator: null,
        grade: null,
        selectedStudentSolution: null,
    }
    componentDidMount = () => {
        console.log(this.props.match.params.exerciseTodayDetailID);
        axios.get('/api/Assignments/GetPresentNotEvaluatedAssignmentsById/'+ this.props.match.params.exerciseTodayDetailID)
            .then( response => {
                this.setState({studentOptions: response.data.presentassignments});
            }).catch(error => {
                console.log(error.response);
            })
        axios.get('/api/Assignments/GetById/'+ this.props.match.params.exerciseTodayDetailID)
            .then(response=> {
                this.setState({evaluator: response.data.sectionid})
            }).catch(error=>{
                console.log(error.response);
            })
    }


    studentChangeHandler = (e, { value }) => {
        this.setState({selectedStudent: value });
        this.setState({selectedStudentSolution: null});
        this.setState({selectedStudentSolution: this.state.studentOptions.solution});
    }

    render() {


        return (
            <div className='gradeothersContainer'>
                <div className='gradeStudents'>
                    <Header size='large'>Oceń innych</Header>
                    <div className='grades'>
                        <Dropdown className="selectStudent" placeholder='Student' search   options={this.state.studentOptions} selection onChange={this.studentChangeHandler} />
                        <Grade assignment={this.state.selectedStudent} section={this.state.evaluator} />
                    </div>

                </div>
                <div className='studentCode'>
                {this.state.selectedStudentSolution ? 
                    <CodeWindow changeMode={true} code={this.state.selectedStudentSolution} />
                    : null
                }
                </div>
            </div>
        );
    }
}

export default withRouter(GradeStudents);