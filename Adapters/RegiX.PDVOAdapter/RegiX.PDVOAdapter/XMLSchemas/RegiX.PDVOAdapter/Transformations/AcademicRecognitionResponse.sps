<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/NACID/PDVO/AcademicRecognitionResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.PDVOAdapter\XMLSchemas\AcademicRecognitionResponse.xsd" workingxmlfile="AcademicRecognitionResponse2.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:AcademicRecognitionResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<styles text-align="center"/>										<children>											<text fixtext="Национален център за информация и документация"/>											<newline/>											<text fixtext="Регистър на признатите дипломи за придобито висше образование в чужбина"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<styles text-align="center"/>										<children>											<text fixtext="Справка за академично признаване на придобито висше образование в чужбина"/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="string-length(. )&gt;0">												<children>													<template match="n1:InternalAppNum" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Деловоден номер">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:InternalAppDate" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Дата">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format string="DD.MM.YYYY" datatype="date"/>																							</content>																							<text fixtext=" г."/>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:AcademicRecognitionStatus" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Статус">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<text fixtext="Име">																						<styles font-style="italic" font-weight="normal"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:FirstName" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:MiddleName" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext=" "/>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																					<template match="n1:LastName" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<text fixtext=" "/>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>													<table>														<properties border="0" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<properties valign="top"/>																		<children>																			<tablecell headercell="1">																				<properties align="left" width="250px"/>																				<children>																					<template match="n1:IdentificatorTypeName" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<content>																								<styles font-style="italic" font-weight="normal"/>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:Identificator" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>													<template match="n1:RecognizedEduLevel" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Призната ОКС">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:RecognizedProfQualName" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Професионална квалификация">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:UniversityOriginalName" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Висше училище в чужбина">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:UniversityNameCyrillic" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Висше училище(на кирилица)">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:CountryNameCyrillic" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Държава">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:SettlementAbroadName" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Град">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:AddressDescriptionAbroad" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Адрес">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<content>																								<format datatype="string"/>																							</content>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:CertificateNums" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Номер на удостоверение">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="n1:CertificateNum" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<paragraph>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</paragraph>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>													<template match="n1:RecognizedSpecialities" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<table>																<properties border="0" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<properties valign="top"/>																				<children>																					<tablecell headercell="1">																						<properties align="left" width="250px"/>																						<children>																							<text fixtext="Признати специалности">																								<styles font-style="italic" font-weight="normal"/>																							</text>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="n1:RecognizedSpecialityName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<paragraph>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</paragraph>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>														</children>													</template>												</children>											</conditionbranch>											<conditionbranch>												<children>													<text fixtext="Не са намерени данни за академично признаване по подадените номер и дата."/>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>