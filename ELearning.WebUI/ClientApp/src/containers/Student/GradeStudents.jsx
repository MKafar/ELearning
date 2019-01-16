import React, { Component } from 'react';
import { Header, Dropdown, Button } from 'semantic-ui-react';
import axios from '../../axios';
import {withRouter} from 'react-router';

import './GradeStudents.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import Grade from '../../components/Grades/Grade';


class GradeStudents extends Component {

    state = {
        studentOptions: [
            { key: '1', text: 'Jan Kowalski', value: '1' },
            { key: '2', text: 'Anna Nowak', value: '2' },
            { key: '3', text: 'Andrzej Nowakowski', value: '3' },
            { key: '4', text: 'Monika Sołtysik', value: '4' },
        ],
        gradeDetails: [],
        selectedStudent: null,
    }
    componentDidMount = () => {
        console.log(this.props.match.params.exerciseTodayDetailID);
        axios.get('/api/Assignments/GetPresentNotEvaluatedAssignmentsById/'+ this.props.match.params.exerciseTodayDetailID)
            .then( response => {
                this.setState({gradeDetails: response.data.presentassignments});
            }).catch(error => {
                console.log(error.response);
            })
    }

    sendGrade = () => {
       console.log('dziala')
    }
    studentChangeHandler = (e, { value }) => {
        this.setState({selectedStudent: value });
    }
    showSolution = () => {
        console.log(this.state.selectedStudent);
        
    }

    render() {


        return (
            <div className='gradeothersContainer'>
                <div className='gradeStudents'>
                    <Header size='large'>Oceń innych</Header>
                    <div className='grades'>
                        <Dropdown className="selectStudent" placeholder='Student' search   options={this.state.studentOptions} selection onChange={this.studentChangeHandler} />
                        <Button className="solutionButton" onClick={this.showSolution}>Pokaż rozwiązanie</Button>
                        <Grade grade={this.sendGrade}/>
                    </div>

                </div>
                <div className='studentCode'>
                    <CodeWindow changeMode={true} code={this.state.gradeDetails.solution} />
                </div>
            </div>
        );
    }
}

export default withRouter(GradeStudents);