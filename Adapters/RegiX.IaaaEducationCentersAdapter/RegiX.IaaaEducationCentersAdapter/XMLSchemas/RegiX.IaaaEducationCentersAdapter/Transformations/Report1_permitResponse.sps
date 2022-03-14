<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/Iaaa/EducationCenters"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/Iaaa/EducationCenters/PermitsResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.IaaaEducationCentersAdapter\XMLSchemas\Report1_permitResponse.xsd" workingxmlfile="Report1_permitResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<newline/>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Изпълнителна агенция „Автомобилна администрация“"/>								</children>							</paragraph>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Регистър за издадените удостоверения за регистрация за организиране на курсове за обучение на водачи за придобиване на квалификация и за усъвършенстване на познанията им"/>								</children>							</paragraph>							<newline/>							<paragraph paragraphtag="h2">								<properties align="center"/>								<children>									<text fixtext="Справка по ЕИК за последните издадени разрешения"/>								</children>							</paragraph>							<template match="n1:PermitResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<condition>										<children>											<conditionbranch xpath="count( n1:Permits ) = 0">												<children>													<text fixtext="Няма данни за издадени разрешения за посочения ЕИК! "/>												</children>											</conditionbranch>											<conditionbranch>												<children>													<template match="n1:Permits" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<template match="n1:Permit" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<paragraph paragraphtag="p">																		<children>																			<autocalc xpath="position()"/>																			<text fixtext=" от "/>																			<autocalc xpath="count ( ../n1:Permit )"/>																			<text fixtext=": "/>																			<template match="common:Number" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Номер на разрешение:">																						<styles font-weight="bold"/>																					</text>																					<text fixtext=" "/>																					<content>																						<format datatype="int"/>																					</content>																				</children>																			</template>																		</children>																	</paragraph>																	<table>																		<properties border="1"/>																		<children>																			<tablebody>																				<children>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Име на фирмата от разрешението"/>																								</children>																							</tablecell>																							<tablecell>																								<children>																									<template match="common:CompanyFullName" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="ЕИК/БУЛСТАТ на фирмата от разрешението"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:CompanyIdentNumber" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Има на управител на фирмата"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:ManagerFullName" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="ЕГН на управител на фирмата"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:ManagerIdentNumber" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Адрес на фирмата"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:Address" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Тип на разрешението (теория/практика/теория и практика"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:PermitType" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Дата на издаване на разрешението"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:IssueDate" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format string="DD.MM.YYYY" datatype="date"/>																											</content>																											<text fixtext=" г."/>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Дата на валидност на разрешението"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:ValidTo" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format string="DD.MM.YYYY" datatype="date"/>																											</content>																											<text fixtext=" г."/>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Дата на прекратяване на разрешението"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:CeaseDate" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="date"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Пълно име на технически сътрудник"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:TechAssistantFullName" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="ЕГН не технически сътрудник"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:TechAssistantIdentNumber" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Име на Регионалната дирекция в която работи разрешението"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:OrgUnitShortName" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Статус на разрешението (издадено/подписано/прекратено"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:Status" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="string"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Брой кабинети за даденото разрешение"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:ExamRoomsCount" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="short"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Брой места за обучение"/>																								</children>																							</tablecell>																							<tablecell>																								<properties align="left"/>																								<children>																									<template match="common:SeatPlacesCount" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="short"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																					<tablerow>																						<children>																							<tablecell headercell="1">																								<properties align="left"/>																								<children>																									<text fixtext="Брой места за изпит"/>																								</children>																							</tablecell>																							<tablecell>																								<children>																									<template match="common:ExamSeatsCount" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<content>																												<format datatype="short"/>																											</content>																										</children>																									</template>																								</children>																							</tablecell>																						</children>																					</tablerow>																				</children>																			</tablebody>																		</children>																	</table>																</children>															</template>														</children>													</template>												</children>											</conditionbranch>										</children>									</condition>									<newline/>								</children>							</template>							<newline/>							<newline/>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>