import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5022/api', // Your API base URL
});

export const fetchStudents = () => api.get('/students');
export const addStudent = (student) => api.post('/students', student);
export const fetchDepartments = () => api.get('/departments');
export const fetchLectures = () => api.get('/lectures');
