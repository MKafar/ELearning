import React, { Component } from 'react';
import { Input, Header, Button } from 'semantic-ui-react';
import axios from '../../axios';

import './StudentDetailsAssignment.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import DetailList from '../../components/Modules/DetailList';

class StudentDetailsAssignment extends Component {

    state = {
         //{ id: 1, name: 'Imię Nazwisko', grade: 5.75 },
        grades: [],
        adminGrade: 0,
        studentCodeContent: '',
        studentEvaluationData: []
    }

    handleChange = (e, { value }) => {
       ((value === '' || value < 0)  ? this.setState({ adminGrade: 0 }) : this.setState({ adminGrade: value })) || ((value > 10) ? this.setState({ adminGrade: 10 }) : this.setState({ adminGrade: value }))
    }

    sendAdminGradeHandler = () => {
        console.log(" Ocena: " + this.state.adminGrade);
        // axios.put('/api/Assignments/Update', {
        //     id: this.props.match.params.studentDetailsExerciseID,
        //     finalGrade: this.state.adminGrade,
        //     date: this.state.studentEvaluationData.assignmentDate,
        //     variantId: this.state.studentEvaluationData.variantId,
        //     sectionId: this.state.studentEvaluationData.sectionId,
        // }).then(response =>{
        //     console.log(response);
        // }).catch(error => {
        //     console.log(error.response);
        // })
            
    }
    loadData = () => {
        axios.get('api/Assignments/GetAllEvaluationsById/'+ this.props.match.params.studentDetailsExerciseID )
            .then(response => {
                this.setState({grades: response.data.assignmentEvaluations })
            }).catch(error => {
                console.log(error.response);
            })

        axios.get('/api/Assignments/GetById/' +this.props.match.params.studentDetailsExerciseID )
            .then(response => {
                this.setState({studentCodeContent: response.data.content });
                console.log(this.state.studentCodeContent);
            }).catch(error => {
                console.log(error.response);
            })
    }

    componentDidMount = () => {
        this.loadData();
        console.log(this.props.match.params);
        console.log(this.props);
    }

    render() {
        return (
            <div className="userAssignmentContainer">
                <div className="assignmentHeaders">
                    <Header size='large'>Zadanie, Wariant: 1, 01.01.19</Header>
                    <Header className="nameHeader" size='medium'>Imię i nazwisko</Header>
                </div>
                <div className='assignmentContentContainer'>
                    <CodeWindow className='studentCodeWindow' changeMode={true} code={'Hello'} />
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
            </div>
        )
    }
}

export default StudentDetailsAssignment;