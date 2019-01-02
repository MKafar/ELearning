import React, { Component } from 'react';
import { Header, Button, Table, Dropdown, Input } from 'semantic-ui-react';

import './StudentDetails.scss';
import DetailList from '../../components/Modules/DetailList';

class StudentDetails extends Component {
    state = {
        studentExercises: [
            { id: 1, title: 'Tytuł zadania', subject: 'PP', date: '01.01.2019', grade: 3.5 },
            { id: 2, title: 'Tytuł zadania', subject: 'PP', date: '01.01.2019', grade: 4.0 },
            { id: 3, title: 'Tytuł zadania', subject: 'PP', date: '01.01.2019', grade: 5.0 },
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
        ]
    }
    render() {
        return (
            <div className='studentdetailsContener'>
                <div className='detailsHeader'>
                    <Header size='large'>Imię i nazwisko studenta</Header>
                </div>
                <div className='studentTables'>
                    <div>
                        {this.state.studentExercises.map((studentExercise) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={false}
                                key={studentExercise.id}
                                title={studentExercise.title}
                                subject={studentExercise.subject}
                                date={studentExercise.date}
                                grade={"Ocena: " + studentExercise.grade} />
                        })}
                    </div>
                    <div>
                    <Dropdown className='studentInput' placeholder='Laboratorium' clearable options={this.subjectOptions} selection />
                    <Dropdown className='studentInput' placeholder='Grupa' clearable options={this.groupOptions} selection />
                    <Input className='sectionInput' placeholder='Sekcja' onChange={this.sectionHandle} />
                    <Button className='addtolistbutton' primary onClick={this.addtolistHandle}>Dodaj</Button>

                    <Table basic='very' className='addstudenttable'>
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