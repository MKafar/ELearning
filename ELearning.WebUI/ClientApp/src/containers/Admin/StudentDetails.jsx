import React, { Component } from 'react';
import { Header, Button, Table, Dropdown, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './StudentDetails.scss';
import DetailList from '../../components/Modules/DetailList';

class StudentDetails extends Component {
    state = {
        studentExercises: [
            {key: 1, title: "Zadanie", group: "Grupa", date: "01.01.19", variant: 1, grade: 4.0}
        ],
        subjectOptions: [
            { key: 1, text: 'Choice 1', value: 1 },
            { key: 2, text: 'Choice 2', value: 2 },
            { key: 3, text: 'Choice 3', value: 3 },
        ],
        groupOptions: [
            { key: 1, text: 'Choice 1', value: 1 },
            { key: 2, text: 'Choice 2', value: 2 },
            { key: 3, text: 'Choice 3', value: 3 },
        ],
        selectedStudentID: null
    }

    componentDidMount = () => {
        axios.get('/api/Assignments/GetById/' + this.state.selectedStudentID)
            .then(response => {
                console.log(response.data);
                //this.setState({studentExercises: response.data.assignments});

            }).catch(error => {
                console.log(error.response);
            })
    }
    componentWillMount = () => {
        this.setState({selectedStudentID: this.props.match.params.studentDetailsID });
    }

    detailsHandler = (studentExerciseDetailID) => {
        this.props.history.push('/students/' + this.props.match.params.studentDetailsID + '/' + studentExerciseDetailID);
    }

    render() {
        return (
            <div className='studentdetailsContener'>
                <div className='detailsHeader'>
                    <Header size='large'>Imię i nazwisko</Header>
                </div>
                <div className='studentTables'>
                    <div className='assignmentTable'>
                        {this.state.studentExercises.map((studentExercise) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={false}
                                key={studentExercise.id}
                                title={studentExercise.title}
                                date={studentExercise.date}
                                variant={'Wariant: ' + studentExercise.variant}
                                group={"Grupa: " + studentExercise.group}
                                grade={"Ocena: " + studentExercise.grade}
                                detailsClicked={()=> this.detailsHandler(studentExercise.id)}
                                 />
                                
                        })}
                    </div>
                    <div className='assignGroup'>
                        <div className='assignInputs'>
                            <Dropdown className='studentInputAssignment' placeholder='Laboratorium' clearable options={this.state.subjectOptions} selection />
                            <Dropdown className='studentInputAssignment' placeholder='Grupa' clearable options={this.state.groupOptions} selection />   
                            <Input className='sectionInputAssignment' placeholder='Sekcja' onChange={this.sectionHandle} />
                            <br />
                            <Button className='addtolistbuttonAssignment' primary onClick={this.addtolistHandle}>Dodaj</Button>
                        </div>

                        <Table basic='very' className='addstudenttableAssignment'>
                            <Table.Header>
                                <Table.Row>
                                    <Table.HeaderCell>Grupa</Table.HeaderCell>
                                    <Table.HeaderCell>Sekcja</Table.HeaderCell>
                                    <Table.HeaderCell></Table.HeaderCell>
                                </Table.Row>
                            </Table.Header>

                            <Table.Body>
                                <Table.Row>
                                    <Table.Cell className='group'>Approved</Table.Cell>
                                    <Table.Cell>None</Table.Cell>
                                    <Table.Cell><Button className='deletetablebutton'>Usuń</Button></Table.Cell>
                                </Table.Row>
                            </Table.Body>
                        </Table>
                    </div>
                </div>
            </div>
        );
    }
}

export default StudentDetails; 