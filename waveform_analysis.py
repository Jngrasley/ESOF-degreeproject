
# Setup
import numpy as np
import wave
import struct
import matplotlib.pyplot as plt
import IPython

from scipy.fftpack import fft
from scipy.io import wavfile

import os

import IPython.display as ipd
from IPython.display import Audio

!pip install SoX
!apt-get install sox libsndfile1 ffmpeg
import sox

#install pydub library
!pip install pydub
from pydub import AudioSegment

import sys
!{sys.executable} -m pip install librosa

import librosa
import librosa.display
import scipy as sp
from scipy import signal
import random



#def readFolder(path):
   #with open(path, 'r') as f:
       # print(f.read())

#path = r"C:\Users\pauls"
#os.chdir(path)
#os.getcwd()

#read from folder 
#path = r"C:\Users\pauls"
#os.chdir(path)
#for file in os.listdir():
    #mp3_to_convert = readFolder(f"{path}\{file}")
    
mp3_to_convert = "000002.mp3"
converted_wav = "converted.wav"                                                            
convertaudio = AudioSegment.from_mp3(mp3_to_convert)
convertaudio.export(converted_wav, format="wav")

#convert number of audio channels to 2 if it is not already
audiochannel2 = sox.file_info.channels('converted.wav')
bits = sox.file_info.bitdepth('converted.wav')
monocheck2 = AudioSegment.from_wav('converted.wav')
if (audiochannel2 == 1):
  monocheck2 = monocheck2.set_channels(2)
monocheck2.export('freq_display.wav', format='wav')

#read the wav data to an array and obtain needed information
fsus, data2 = wavfile.read('freq_display.wav')
sample_rate2 = sox.file_info.sample_rate('freq_display.wav')
num_samples2 = sox.file_info.num_samples('freq_display.wav')

#1st audio channel
ch1 = data2.T[0]
ch1_norm=[(i/2**8.)*2-1 for i in ch1] #normalized on [-1,1)
ch1_fft = fft(ch1_norm)
ch1_frequencies = np.absolute(ch1_fft[:num_samples2//2]) #the spectrum of frequencies in ch1

#2nd audio channel
ch2 = data2.T[1]
ch2_norm=[(i/2**8.)*2-1 for i in ch2] #normalized on [-1,1)
ch2_fft = fft(ch1_norm)
ch2_frequencies = np.absolute(ch2_fft[:num_samples2//2]) #the spectrum of frequencies in ch2



#plot time and frequency domains of signal
plt.figure(figsize=(15,15))

plt.subplot(3,1,1)

#time info
plt.plot(data2[:num_samples2], color='orangered')
plt.title("Audio Wave: Time Domain")
plt.xlabel("Sample Number")
plt.ylabel("Amplitude (Audio Volume)")

plt.subplots_adjust(hspace=.5)
plt.subplot(3,1,2)

#frequency ch1 info
plt.plot(np.linspace(0, sample_rate2/2, num_samples2//2), ch1_frequencies, color='coral')
plt.title("Audio Wave: Frequency Domain: Audio Channel 1")
plt.xlabel("Frequency (Hz)")
plt.ylabel("Spectrum")

plt.subplots_adjust(hspace=.5)
plt.subplot(3,1,3)

#frequency ch2 info
plt.plot(np.linspace(0, sample_rate2/2, num_samples2//2), ch2_frequencies, color='orangered')
plt.title("Audio Wave: Frequency Domain: Audio Channel 2")
plt.xlabel("Frequency (Hz)")
plt.ylabel("Spectrum")

#np.max(ch1_frequencies)
np.max(ch2_frequencies)


x, sr = librosa.load('converted.wav')
plt.figure(figsize=(20, 4))
librosa.display.waveplot(x, sr=sr)

zero_crossings = librosa.zero_crossings(x[0:1000000], pad=False)#10million gives the max zero crossings
print(sum(zero_crossings))

