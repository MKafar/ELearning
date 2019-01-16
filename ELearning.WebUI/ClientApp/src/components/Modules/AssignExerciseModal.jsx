import React, { Component } from 'react';
import { Button, Modal, Input, Dropdown } from 'semantic-ui-react';
import axios from '../../axios';

import './AssignExerciseModal.scss';

class AssignExerciseModal extends Component {
    state = {
        subjectOptions: [],
        groupOptions: [],
        sectionOptions: [],
        exerciseOptions: [],
        variantOptions: [],

        subjectAllOptions: [],
        groupAllOptions: [],
        sectionAllOptions: [],
        exerciseAllOptions: [],
        variantAllOptions: [],

        subject: null,
        group: null,
        section: null,
        exercise: null,
        variant: null,
        date: null,
        time: null,
    }

    componentDidMount = () => {
        this.loadData();
    }

    loadData = () => {
        axios.get('/api/Subjects/GetAll').then(response => {
            const sub = response.data.subjects;
            let i;

            for (i = 0; i < sub.length; i++) {
                sub[i].text = sub[i]['name'];
                sub[i].key = sub[i]['id'];
                sub[i].value = sub[i]['id'];

            }
            this.setState({subjectOptions: response.data.subjects});
            this.setState({subjectAllOptions: response.data.subjects});            
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Groups/GetAll').then(response => {
            const gr = response.data.groups;
            let i;

            for (i = 0; i < gr.length; i++) {
                gr[i].text = gr[i]['name'];
                gr[i].key = gr[i]['id'];
                gr[i].value = gr[i]['id'];
            }
            this.setState({groupOptions: response.data.groups});
            this.setState({groupAllOptions: response.data.groups});
            //console.log(this.state.groupOptions);
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Sections/GetAll').then(response => {
            const sec = response.data.sections;
            let i;

            for (i = 0; i < sec.length; i++) {
                sec[i].text = sec[i]['number'];
                sec[i].key = sec[i]['id'];
                sec[i].value = sec[i]['id'];
            }
            this.setState({sectionOptions: response.data.sections});
            this.setState({sectionAllOptions: response.data.sections});
            //console.log(this.state.sectionOptions);
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Exercises/GetAll').then(response => {
            const ex = response.data.exercises;
            let i;

            for (i = 0; i < ex.length; i++) {
                ex[i].text = ex[i]['title'];
                ex[i].key = ex[i]['id'];
                ex[i].value = ex[i]['id'];
            }
            this.setState({exerciseOptions: response.data.exercises});
            this.setState({exerciseAllOptions: response.data.exercises});
            //console.log(this.state.exerciseOptions);
        }).catch(error => {
            console.log(error.response);
        })

        axios.get('/api/Variants/GetAll').then(response => {
            const va = response.data.variants;
            let i;

            for (i = 0; i < va.length; i++) {
                va[i].text = va[i]['number'];
                va[i].key = va[i]['id'];
                va[i].value = va[i]['id'];
                delete va[i].content;
            }
            this.setState({variantOptions: response.data.variants});
            this.setState({variantAllOptions: response.data.variants});
            console.log("AssignExerciseModal component. Variants/GetAll response.data.variants: ", this.state.variantOptions);
        }).catch(error => {
            console.log("AssignExerciseModal component. Variants/GetAll error.response: ", error.response);
        })
    }

    // subjectChangeHandler = (e, { value }) => {
    //     this.setState({ groupOptions: this.state.groupAllOptions });

    //     this.setState({ subject: value });
        
    //     if (value != null)
    //     {
    //         let groupsListByValue = [];

    //         this.state.groupOptions.map((entity) => {
    //             for (let property in entity)
    //             {
    //                 if (property === "subjectid" && entity[property] == value)
    //                 {
    //                     groupsListByValue.push(entity);
    //                 }
    //             }
    //         })

    //         this.setState({ groupOptions: groupsListByValue });
    //     }
    // }

    // groupChangeHandler = (e, { value }) => {
    //     this.setState({ sectionOptions: this.state.sectionAllOptions });
    //     this.setState({ group: value });

    //     let sectionsListByValue = [];
        
    //     this.state.sectionOptions.map((entity) => {
    //         for (let property in entity)
    //         {
    //             if (property === "groupid" && entity[property] == value)
    //             {
    //                 sectionsListByValue.push(entity);
    //             }
    //         }
    //     })
        
    //     this.setState({ sectionOptions: sectionsListByValue });
    //     sectionsListByValue = [];
    // }

    // sectionChangeHandler = (e, { value }) => {
    //     this.setState({ section: value });
    // }

    // exerciseChangeHandler = (e, { value }) => {
    //     this.setState({ exerciseOptions: this.state.exerciseAllOptions });
    //     this.setState({ exercise: value });

    //     let exercisesListByValue = [];
        
    //     this.state.exerciseOptions.map((entity) => {
    //         for (let property in entity)
    //         {
    //             if (property === "variantid" && entity[property] == value)
    //             {
    //                 exercisesListByValue.push(entity);
    //             }
    //         }
    //     })

    //     this.setState({ exerciseOptions: exercisesListByValue });
    //     exercisesListByValue = [];
    // }
    // variantChangeHandler = (e, { value }) => {
    //     this.setState({ variant: value });
    // }
    // dataChangeHandler = (e) => {
    //     this.setState({ date: e.target.value });
    // }

    subjectChangeHandler = (e, { value }) => {
        this.setState({ subject: value });
    }
    groupChangeHandler = (e, { value }) => {
        this.setState({ group: value });
    }

    sectionChangeHandler = (e, { value }) => {
        this.setState({ section: value });
    }
    exerciseChangeHandler = (e, { value }) => {
        this.setState({ exercise: value });
    }
    variantChangeHandler = (e, { value }) => {
        this.setState({ variant: value });
    }
    dataChangeHandler = (e) => {
        this.setState({ date: e.target.value });
    }
    hourChangeHandler = (e) => {
        this.setState({ time: e.target.value });
    }

    addHandle = () => {
        const sectionId = this.state.section;
        const variantId = this.state.variant;
        let assignmentDate = this.state.date;
        assignmentDate = assignmentDate.split("-").reverse().join("-");
        const assgnmentTime = this.state.time;
        console.log('Time',assgnmentTime );
        console.log('Date',assignmentDate );
        console.log('Variant',variantId );
        console.log('Section',sectionId );

        axios.post('/api/Assignments/Create', {
            sectionid: sectionId,
            variantid: variantId,
            date: assignmentDate,
            time: assgnmentTime,
        }).then( response => {
            console.log(response);
        }).catch(error => {
            console.log(error.response);
        })
    }

    render() {

        return (
            <Modal closeIcon trigger={<Button className='assignexercisebutton' primary>Przypisz zadanie</Button>} centered={false}>
                <Modal.Header>Przypisz zadanie</Modal.Header>
                <Modal.Content  className="modalContent">
                    <Dropdown className='studentInput' placeholder='Przedmiot'  options={this.state.subjectOptions} selection onChange={this.subjectChangeHandler} />
                    <Dropdown className='studentInput' placeholder='Grupa'  options={this.state.groupOptions} selection onChange={this.groupChangeHandler} disabled={false}/>
                    <Dropdown className='studentInput' placeholder='Sekcja'  options={this.state.sectionOptions} selection onChange={this.sectionChangeHandler}/>
                    <Dropdown className='studentInput' placeholder='Zadanie'  options={this.state.exerciseOptions} selection onChange={this.exerciseChangeHandler}/>
                    <Dropdown className='variantAssignmentInput' placeholder='Wariant' options={this.state.variantOptions} selection onChange={this.variantChangeHandler} />
                    <br />
                    <Input className='dateInput' type='date' label='Data' placeholder='DD-MM-RRRR' onChange={this.dataChangeHandler} />
                    <Input className='dateInput' type='time' label='Godz.'  onChange={this.hourChangeHandler} />
                </Modal.Content>
                <Modal.Actions>
                    <Button primary onClick={this.addHandle}>Zapisz</Button>
                </Modal.Actions>
            </Modal>
        )
    }

}

export default AssignExerciseModal
