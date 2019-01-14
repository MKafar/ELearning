import React, { Component } from 'react';
import { Header, Dropdown } from 'semantic-ui-react';
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
        gradeDetails: []
    }
    componentDidMount = () => {
        axios.get('/api/Assignments/GetPresentNotEvaluatedAssignmentsById/'+ this.props.match.params.exerciseTodayDetailID)
            .then( response => {
                this.setState({gradeDetails: response.data.presentassignments});
            }).catch(error => {
                console.log(error.response);
            })
    }

    render() {


        return (
            <div className='gradeothersContainer'>
                <div className='gradeStudents'>
                    <Header size='large'>Oceń innych</Header>
                    <div className='grades'>
                        <Dropdown placeholder='Student' search selection options={this.state.studentOptions} />
                        <Grade />
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