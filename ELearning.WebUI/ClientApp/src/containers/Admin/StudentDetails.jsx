import React, { Component } from 'react';
import { Header, Button, Dropdown, Input } from 'semantic-ui-react';
import axios from '../../axios';

import './StudentDetails.scss';
import DetailList from '../../components/Modules/DetailList';

class StudentDetails extends Component {
    state = {
        studentExercises: [],
        studentName: '',
        groupOptions: [],
        selectedStudentID: null,
        studentGroupsAndSections: [],
        sectionInput: null,
        groupInput: null,
        assignmentData:[]
    }
    loadData = () => {
        axios.get('/api/Users/GetAllAssignmentsWithDetailsById/' + this.state.selectedStudentID)
            .then(response => {
                this.setState({ studentExercises: response.data.userAssignmentsWithDetails });
                console.log( this.state.studentExercises);
            }).catch(error => {
                console.log(error.response);
            })

        axios.get('/api/Groups/GetAll')
            .then(response => {

                const gr = response.data.groups;
                let i;

                for (i = 0; i < gr.length; i++) {
                    gr[i].text = gr[i]['name'];
                    gr[i].key = gr[i]['id'];
                    gr[i].value = gr[i]['id'];
                    delete gr[i].name;
                    delete gr[i].id;
                }
                this.setState({ groupOptions: response.data.groups });
            }).catch(error => {
                console.log(error.response);
        })

        axios.get('/api/Users/GetAllSectionsById/' + this.state.selectedStudentID)
            .then(response => {
                this.setState({ studentGroupsAndSections: response.data.sections });
            }).catch(error => {
                console.log(error.response);
        })

        axios.get('/api/Users/GetById/' + this.state.selectedStudentID)
            .then( response => {
                this.setState({studentName: response.data.name })
            }).catch(error => {
                console.log(error.response);
            })
    }

    componentDidMount = () => {
        this.loadData();
        
    }

    componentWillMount = () => {
        this.setState({ selectedStudentID: this.props.match.params.studentDetailsID });
    }

    detailsHandler = (studentExerciseDetailID) => {
        this.props.history.push({
            pathname: '/students/' + this.props.match.params.studentDetailsID + '/' + studentExerciseDetailID  });
    }

    addtolistHandle = () => {
        const inputSection = this.state.sectionInput;
        const inputGroup= this.state.groupInput;
        const student = this.state.selectedStudentID;

        axios.post('/api/Sections/Create', {
            number: inputSection,
            groupId: inputGroup,
            userId: student
        })
            .then(response => {
                console.log(response.data);
                this.loadData();
            })
            .catch(error => {
                console.log(error.response);
                alert("Nie można dodać sekcji!")
            })


    }

    sectionHandle = (e) => {
        this.setState({ sectionInput: e.target.value });
    }

    groupHandle = (e, { value }) => {
        this.setState({ groupInput: value });
    }

    removeHandler = (studentGroupAndSectionRemoveID) => {
        axios.delete('/api/Sections/Delete/' + studentGroupAndSectionRemoveID)
            .then(response => {
                console.log(response);
                this.loadData();
            }).catch(error => {
                console.log(error.response);
                alert("Nie można usunąć sekcji!");
            });
    }

    render() {
        return (
            <div className='studentdetailsContener'>
                <div className='detailsHeader'>
                    <Header size='large'>{this.state.studentName}</Header>
                </div>
                <div className='studentTables'>
                    <div className='assignmentTable'>
                        {this.state.studentExercises.map((studentExercise) => {
                            return <DetailList
                                visibledetail={true}
                                visibledelete={false}
                                key={studentExercise.assignmentId}
                                title={studentExercise.exerciseTitle + " "}
                                date={studentExercise.assignmentDate}
                                variant={'Wariant: ' + studentExercise.variantNumber}
                                group={"Grupa: " + studentExercise.groupName + " "}
                                finalgrade={" Ocena: " + studentExercise.assignmentFinalGrade}
                                detailsClicked={() => {
                                     this.detailsHandler(studentExercise.assignmentId); 
                                }}
                            />
                        })}
                    </div>
                    <div className='assignGroup'>
                        <div className='assignInputs'>
                            <Dropdown className='studentInputAssignment' placeholder='Grupa' clearable options={this.state.groupOptions} onChange={this.groupHandle} selection />
                            <Input className='sectionInputAssignment' placeholder='Sekcja' onChange={this.sectionHandle} />
                            <Button className='addtolistbuttonAssignment' primary onClick={this.addtolistHandle}>Dodaj</Button>
                        </div>
                        <div className='studentGroupTable'>
                            {this.state.studentGroupsAndSections.map((groupsadnsections) => {
                                return <DetailList
                                    visibledetail={false}
                                    visibledelete={true}
                                    key={groupsadnsections.sectionId}
                                    id={groupsadnsections.sectionId}
                                    group={"Grupa: " + groupsadnsections.groupName + " "}
                                    section={" Sekcja: " + groupsadnsections.sectionNumber}
                                    removeClicked={() => this.removeHandler(groupsadnsections.sectionId)}
                                />
                            })}
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

export default StudentDetails; 