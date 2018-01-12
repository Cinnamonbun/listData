% Import data from text file.
% Most code automatically generated by Matlab R2016b
% Initialize variables.
% Make sure when running importRandomData.m, that the txt file is in the
% same directory as importantRandomData.m!
filename = '\listDataTest.m';
delimiter = '';
% Format string for each line of text:
formatSpec = '%f%[^\n\r]';
% Open the text file.
fileID = fopen(filename,'r');
% Read columns of data according to format string.
dataArray = textscan(fileID, formatSpec, 'Delimiter', delimiter,  'ReturnOnError', false);
% Close the text file.
fclose(fileID);
RandomDataImport = dataArray{:, 1};
clearvars filename delimiter formatSpec fileID dataArray ans;