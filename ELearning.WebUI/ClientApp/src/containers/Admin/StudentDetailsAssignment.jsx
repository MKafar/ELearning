import React, { Component } from 'react';
import { Input, Header, Button } from 'semantic-ui-react';
import axios from '../../axios';
import {withRouter} from 'react-router-dom';

import './StudentDetailsAssignment.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import DetailList from '../../components/Modules/DetailList';

class StudentDetailsAssignment extends Component {

    state = {
         //{ id: 1, name: 'Imię Nazwisko', grade: 5.75 },
        grades: [],
        adminGrade: 0,
        studentCodeContent: '',
        studentEvaluationData: [],
        studentAssignments: null,
        assignmentID: null,
        studentAssignmentData: null,
        student: ''
    }

    handleChange = (e, { value }) => {
       ((value === '' || value < 0)  ? this.setState({ adminGrade: 0 }) : this.setState({ adminGrade: value })) || ((value > 10) ? this.setState({ adminGrade: 10 }) : this.setState({ adminGrade: value }))
    }

    sendAdminGradeHandler = () => {
        axios.put('/api/Assignments/Update', {
            id: this.props.match.params.studentDetailsExerciseID,
            finalGrade: this.state.adminGrade,
            date: this.state.studentAssignmentData.assignmentDate,
            variantId: this.state.studentAssignmentData.variantId,
            sectionId: this.state.studentAssignmentData.sectionId,
        }).then(response =>{
            console.log(response);
        }).catch(error => {
            console.log(error.response);
        })       
    }

    loadData = () => {
        axios.get('api/Assignments/GetAllEvaluationsById/' + this.props.match.params.studentDetailsExerciseID)
            .then(response => {
                this.setState({ grades: response.data.assignmentEvaluations })
            }).catch(error => {
                console.log(error.response);
            })

        axios.get('/api/Assignments/GetById/' + this.props.match.params.studentDetailsExerciseID)
            .then(response => {
                this.setState({ studentCodeContent: response.data.content });
                //console.log(this.state.studentCodeContent);
            }).catch(error => {
                console.log(error.response);
            })
        axios.get('/api/Users/GetById/'+this.props.match.params.studentDetailsID)
            .then(response => {
                this.setState({student: response.data.name})
            }).catch(error => {
                console.log(error.response);
            })
        axios.get('/api/Users/GetAllAssignmentsWithDetailsById/' + this.props.match.params.studentDetailsID)
            .then(response => {
                this.setState({ studentAssignments: response.data.userAssignmentsWithDetails });
                this.setState({assignmentID: this.props.match.params.studentDetailsExerciseID});
                const assignment = this.state.studentAssignments;
                let studentassignment;

                assignment.map((obj) => {
                    for (let property in obj)
                    {
                        if (property === "assignmentId" && obj[property] == this.state.assignmentID)
                        {
                            studentassignment = obj;
                        }
                    }
                })
                this.setState({studentAssignmentData: studentassignment});

            }).catch(error => {
                console.log(error.response);
            })
    }

    componentDidMount = () => {
        this.loadData();
        //"Danestudenta:" + this.props.match.params.studentDetailsID
        //"Dane assignment: "+ this.props.match.params.studentDetailsExerciseID
    }

    render() {
        return (
            this.state.studentAssignmentData && this.state.student ?
            <div className="userAssignmentContainer">
                <div className="assignmentHeaders">
                    <Header size='large'>{"Zadanie: " +this.state.studentAssignmentData.exerciseTitle } &nbsp; {" Wariant: " + this.state.studentAssignmentData.variantNumber} &nbsp; &nbsp;{" Data: " + this.state.studentAssignmentData.assignmentDate}</Header>
                    <Header className="nameHeader" size='medium'>Student: {this.state.student}</Header>
                </div>
                <div className='assignmentContentContainer'>
                    <CodeWindow className='studentCodeWindow' changeMode={true} code={this.state.studentCodeContent} />
                    <div className='assignmentGradeContainer'>
                        <div className='gradeDetailList'>
                            {this.state.grades.map((grade) => {
                                return <DetailList
                                    visibledetail={false}
                                    visibledelete={false}
                                    key={grade.evaluationId}
                                    id={grade.evaluationId}
                                    name={grade.studentsName}
                                    studentgrade={grade.grade+ " pkt."} />
                            })}

                        </div>

                        <Header size='medium'>Ostateczna ocena</Header>
                        <div className='adminGrade'>
                            <Input className='studentGradeInput' type='number' label={{ basic: true, content: 'pkt.' }} labelPosition='right' placeholder='Ocena' max={10} min={0} step={0.25} onChange={this.handleChange}></Input>
                            <Button primary  className='adminGradeSendButton' onClick={this.sendAdminGradeHandler}>Wyślij</Button>
                        </div>

                    </div>
                </div>
            </div> : null
        )
    }
}

export default withRouter(StudentDetailsAssignment);