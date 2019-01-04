import React, { Component } from 'react';
import { Input, Header, Button } from 'semantic-ui-react';

import './StudentDetailsAssignment.scss';
import CodeWindow from '../../components/Modules/CodeWindow';
import DetailList from '../../components/Modules/DetailList';

class StudentDetailsAssignment extends Component {

    state = {
        grades: [
            { id: 1, name: 'Imię Nazwisko', grade: 5.75 },
            { id: 2, name: 'Imię Nazwisko', grade: 5.5 },
            { id: 3, name: 'Imię Nazwisko', grade: 5 },
            { id: 4, name: 'Imię Nazwisko', grade: 2.5 },
            { id: 5, name: 'Imię Nazwisko', grade: 5.75 },
            { id: 6, name: 'Imię Nazwisko', grade: 5.5 },
            { id: 7, name: 'Imię Nazwisko', grade: 5 },
            { id: 8, name: 'Imię Nazwisko', grade: 2.5 },
            { id: 9, name: 'Imię Nazwisko', grade: 5 },
            { id: 10, name: 'Imię Nazwisko', grade: 2.5 },
        ],
        adminGrade: 0,
    }

    handleChange = (e, { value }) => {
       ((value === '' || value < 0)  ? this.setState({ adminGrade: 0 }) : this.setState({ adminGrade: value })) || ((value > 10) ? this.setState({ adminGrade: 10 }) : this.setState({ adminGrade: value }))
    }

    sendAdminGradeHandler = () => {
        console.log(" Ocena: " + this.state.adminGrade);
    }

    componentDidMount = () => {
        console.log(this.props.match.params.studentDetailsExerciseID)
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
                                    key={grade.id}
                                    id={grade.id}
                                    name={grade.name}
                                    studentgrade={grade.grade} />
                            })}

                        </div>

                        <Header size='medium'>Ostateczna ocena</Header>
                        <div className='adminGrade'>
                            <Input className='studentGradeInput' type='number' label={{ basic: true, content: 'pkt.' }} labelPosition='right' placeholder='Ocena' max={10} min={0} step={0.25} onChange={this.handleChange}></Input>
                            <Button primary className='adminGradeSendButton' onClick={this.sendAdminGradeHandler}>Wyślij</Button>
                        </div>

                    </div>
                </div>
            </div>
        )
    }
}

export default StudentDetailsAssignment;